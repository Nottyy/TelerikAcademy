function onFindBiggerButtonClick() {
    var number = parseInt(document.getElementById('tb-first').value);

    var findBit = (number >> 3) & 1;

    console.log('The third bit is ' + findBit);
}