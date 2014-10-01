function onFindBiggerButtonClick() {
    var firstNum = parseInt(document.getElementById('tb-first').value);
    var secondNum = parseInt(document.getElementById('tb-second').value);
    var thirdNum = parseInt(document.getElementById('tb-third').value);
    var countNegativeNumbers = 0;

    if (firstNum < 0) {
        countNegativeNumbers += 1;
    }

    if (secondNum < 0) {
        countNegativeNumbers += 1;
    }

    if (thirdNum < 0) {
        countNegativeNumbers += 1;
    }

    if (countNegativeNumbers % 2 === 0) {
        console.log('The sign of the product of the three numbers: ' + firstNum + ',' + secondNum + ',' + thirdNum + '' + ' is "+"');
    }
    else {
        console.log('The sign of the product of the three numbers: ' + firstNum + ',' + secondNum + ',' + thirdNum + '' + ' is "-"');
    }

}