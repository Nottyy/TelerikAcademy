function onFindBiggerButtonClick() {
    var firstNum = parseInt(document.getElementById('tb-first').value);
    var secondNum = parseInt(document.getElementById('tb-second').value);
    var thirdNum = parseInt(document.getElementById('tb-third').value);
    var biggestNum;

    if (firstNum > secondNum) {
        if (firstNum > thirdNum) {
            biggestNum = firstNum;
        }
        else {
            biggestNum = thirdNum;
        }
    }
    else {
        if (secondNum > thirdNum) {
            biggestNum = secondNum;
        }
        else {
            biggestNum = thirdNum;
        }
    }
    
    console.log('The biggest num is: ' + biggestNum);

}