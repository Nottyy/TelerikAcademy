function onFindBiggerButtonClick() {
    var num = parseInt(document.getElementById('tb-first').value);

    if (num < 0 || num > 999) {
        console.log('Please enter number in the range: 0-999! Your number is wrong!')
    }
    else {
        function getLastDigit(num) {
            var lastDigit = num % 10;

            switch (lastDigit) {
                case 1: return ("one"); break;
                case 2: return ("two"); break;
                case 3: return ("three"); break;
                case 4: return ("four"); break;
                case 5: return ("five"); break;
                case 6: return ("six"); break;
                case 7: return ("seven"); break;
                case 8: return ("eight"); break;
                case 9: return ("nine"); break;
            }
        }
        var numToString = '';

        if (num < 10) {
            numToString = getLastDigit(num);
        }
        else {
            function getNumberBetweenTenAndNinety(num) {
                switch (num) {
                    case 10: return ("ten"); break;
                    case 11: return ("eleven"); break;
                    case 12: return ("twelve"); break;
                    case 13: return ("thirteen"); break;
                    case 14: return ("fourteen"); break;
                    case 15: return ("fifteen"); break;
                    case 16: return ("sixteen"); break;
                    case 17: return ("seventeen"); break;
                    case 18: return ("eighteen"); break;
                    case 19: return ("nineteen"); break;
                }
            }
            function getDecimalDigit(num) {
                var decimal = Math.floor(num / 10)
                return decimal;
            }
            function getDecimalValue(num) {
                var decimalDigit = getDecimalDigit(num);
                switch (decimalDigit) {
                    case 2: return ('twenty'); break;
                    case 3: return ('thirty'); break;
                    case 4: return ('fourty'); break;
                    case 5: return ('fifty'); break;
                    case 6: return ('sixty'); break;
                    case 7: return ('seventy'); break;
                    case 8: return ('eighty'); break;
                    case 9: return ('ninety'); break;
                }
            }
            if (num < 100) {

                if (num >= 10 && num < 20) {
                    numToString = getNumberBetweenTenAndNinety(num);
                }
                else {
                    var decimalValue = getDecimalValue(num);

                    if (num % 10 === 0) {
                        numToString = decimalValue;
                    }
                    else {
                        numToString = decimalValue + ' ' + getLastDigit(num);
                    }
                }
            }
            else {
                function getHundreds(num) {
                    var getHundreds = Math.floor(num / 100);
                    return getHundreds;
                }
                var getFirstDigit = getHundreds(num);
                numToString = getLastDigit(getFirstDigit);
                numToString += ' hundred';

                if (num % 100 === 0) {
                    console.log(numToString);
                }
                else {
                    var numberAfterHundreds = num % 100;

                    if (numberAfterHundreds < 10) {
                        numToString += ' and ' + getLastDigit(numberAfterHundreds);
                    }
                    else if (numberAfterHundreds >= 10 && numberAfterHundreds < 20) {
                        numToString += ' and ' + getNumberBetweenTenAndNinety(numberAfterHundreds);
                        
                    }
                    else {
                        if (numberAfterHundreds % 10 === 0) {
                            numToString += ' and ' + getDecimalValue(numberAfterHundreds);
                        }
                        else {
                            numToString += ' and ' + getDecimalValue(numberAfterHundreds) + ' ' + getLastDigit(numberAfterHundreds);
                        }
                    }
                }
            }
        }
        console.log(numToString);
    }
}