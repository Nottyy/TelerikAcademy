function onFindBiggerButtonClick() {
    var firstInt = parseInt(document.getElementById('tb-first').value);
    var secondInt = parseInt(document.getElementById('tb-second').value);
    var temp = 0;

    if (firstInt > secondInt) {
        temp = firstInt;
        firstInt = secondInt;
        secondInt = temp;
    }

    console.log(firstInt);
    console.log(secondInt);
}