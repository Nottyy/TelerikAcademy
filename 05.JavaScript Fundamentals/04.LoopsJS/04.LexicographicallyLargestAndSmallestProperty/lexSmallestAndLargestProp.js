function lexSmallestAndLargestProp() {
    var arr1 = [window, navigator, document];

    for (var i = 0; i < 3; i++) {
        var outTxt = "";
        var arr;
        for (var property in arr1[i]) {
            outTxt += property + " ";
        }
        arr = outTxt.split(" ");
        arr.sort();
        outTxt = arr1[i] + "\nMin: " + arr[1] + ";\nMax: " + arr[arr.length - 1] + ";" + '\n';
        console.log(outTxt);
    }
}