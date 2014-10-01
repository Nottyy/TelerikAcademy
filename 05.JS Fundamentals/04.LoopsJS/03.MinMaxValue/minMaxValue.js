function minMaxValue() {
    var inputValue = document.getElementById('tb-first').value;
    var arr = inputValue.split(' ');
    arr.sort(function (a, b) {
        return b - a;
    });
    var outTxt = "Min:" + arr[0] + "; Max:" + arr[arr.length - 1] + ";";
    if ((isNaN(parseInt(arr[arr.length - 1])) && isNaN(parseFloat(arr[arr.length - 1])))
        || (isNaN(parseInt(arr[0])) && isNaN(parseFloat(arr[0])))) {
        outTxt = "Invalid input!";
    }

    console.log(outTxt);
}