function onFindBiggerButtonClick() {
    var number = parseInt(document.getElementById('tb-first').value);

    var isSeven = (Math.floor(number / 100)) % 10;
    var isThirdDigit7 = false;

    if (isSeven === 7) {
        isThirdDigit7 = true;
        console.log(number + ' ---> ' + isThirdDigit7);
    }
    else {
        console.log(number + ' ---> ' + isThirdDigit7);
    }
}