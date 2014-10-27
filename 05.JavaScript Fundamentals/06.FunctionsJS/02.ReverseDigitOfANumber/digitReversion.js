function reverseDigits() {
    var number = 1045;
    var str = number.toString();
    var result = "";
    var i;

    for (i = str.length - 1; i >= 0; i--) {
        result += (str.substr(i, 1));
    }

    console.log(result);
}
