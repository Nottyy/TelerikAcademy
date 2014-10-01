/// <reference path="c:\users\toshiba\documents\visual studio 2013\Projects\WebStorages\GuessingGame\Scripts/jquery-2.1.1.min.js" />
$(document).ready(function () {
    $('.start-game').on('click', startGame);
    var NUMBERLENGTH = 4;

    function startGame() {
        var randomNumber = generateRandomNumber(),
            count = 0;
        checkNumber(randomNumber);

        $('.start-game').hide();
        $('.system-message').show();
        $('.guess-input').show();
        $('.btn-try').show().on('click', function () {
            count += 1;
            checkSuggestion(randomNumber, count);
        });
    };

    function checkSuggestion(realNumber, count) {
        console.log(realNumber);
        var guess = parseInt($('.guess-input').val());
        checkNumber(guess);

        var ramsObj = checkRams(guess, realNumber);
        var sheep = checkSheep(guess, realNumber, ramsObj.unavailablePositions);
        $('.rams-sheep').html('RAMS ' + rams + '<br>' + 'SHEEP ' + sheep);

        if (rams === 4) {
            $('.rams-sheep').hide();
            $('.btn-try').hide();
            $('.enter-nickname').show();
            $('.system-message').html('Congratulations! You have revealed the Four Digit Number with ' + count + ' shots');
            $('.guess-input').hide();
            $('.nickname-input').show();
            $('.btn-enter-nickname').show().on('click', function () {
                var nickname = $('.nickname-input').val();
                console.log(nickname);
                //$('.btn-enter-nickname').hide();
                localStorage.setItem(nickname, count);
                loadPairs();
            });
        }

    };

    function loadPairs() {
        var highScores = [],
            sortable = [],
            allResults = 'Top five results: ' + '<br>',
            playerResult = '',
            nickName,
            score;

        for (var i = 0; i < localStorage.length; i++) {
            nickName = localStorage.key(i);
            score = localStorage.getItem(nickName);
            highScores[nickName] = score;
        }

        for (var player in highScores) {
            sortable.push([player, highScores[player]]);
            sortable.sort(function (a, b) {
                return a[1] - b[1];
            });
        }

        for (var i = 0; i < 5; i++) {
            playerResult = sortable[i][0] + ': ' + sortable[i][1] + ((sortable[i][1] == 1) ? ' shot' : ' shots');
            allResults += (i+1) + " -> " + playerResult + '<br>';
        }

        $('.rams-sheep').show().html(allResults);
    };
    
    function checkRams(guess, realNumber) {
        var guessToString = guess.toString(),
            realNumberToString = realNumber.toString(),
            unavailablePositions = [];
            rams = 0,
            i;

        for (var i = 0; i < NUMBERLENGTH; i++) {
            if (guessToString[i] === realNumberToString[i]) {
                unavailablePositions[i] = true;
                rams += 1;
            }
        }

        return {
            rams: rams,
            unavailablePositions: unavailablePositions
        };
    }

    function checkSheep(guess, realNumber, unavailablePositions) {
        var guessToStringArray = guess.toString().split(''),
            realNumberToString = realNumber.toString(),
            sheep = 0,
            i,
            j;
        for (var i = 0; i < NUMBERLENGTH; i++) {
            if (unavailablePositions[i]) {
                guessToStringArray[i] = 'x';
            }
        }

        
        for (var i = 0; i < NUMBERLENGTH; i++) {
            var currentRealNumberDigit = realNumberToString[i];

            for (var j = 0; j < NUMBERLENGTH; j++) {
                var currentGuessDigit = guessToStringArray[j];

                if (currentGuessDigit === currentRealNumberDigit) {
                    sheep += 1;
                    guessToStringArray[j] = 'x';
                    break;
                }
            }
        }

        return sheep;
    }

    function generateRandomNumber() {
        var minNumber = 1000;
        var maxNumber = 9999;
        var generatedRandomNumber = Math.floor(Math.random() * (maxNumber - minNumber + 1)) + minNumber;

        return generatedRandomNumber;
    };

    function checkNumber(number) {
        if (number < 1000 || number > 9999) {
            $('#header').show().html('The number must be in the range 1000 - 9999 !!!').fadeOut(3000);
            throw new RangeError("The number must be in the range '1000 - 9999'!");
        }
    }
    

});