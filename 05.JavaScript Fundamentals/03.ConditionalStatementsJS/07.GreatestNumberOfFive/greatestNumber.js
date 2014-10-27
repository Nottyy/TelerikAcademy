function onFindBiggerButtonClick() {
    var arr = new Array(5);
    arr[0] = parseInt(document.getElementById('tb-first').value);
    arr[1] = parseInt(document.getElementById('tb-second').value);
    arr[2] = parseInt(document.getElementById('tb-third').value);
    arr[3] = parseInt(document.getElementById('tb-fourth').value);
    arr[4] = parseInt(document.getElementById('tb-fifth').value);
    var theBiggest = arr[0];
    var i;

    if (isNaN(arr[0]) || isNaN(arr[1]) || isNaN(arr[2]) || isNaN(arr[3]) || isNaN(arr[4])) {
        console.log("All must be numbers");
    }
    else {
        for (i = 1; i < arr.length; i++) {
            if (theBiggest < arr[i]) {
                theBiggest = arr[i];
            }
        }
        console.log("The greatest number is: " + theBiggest);
    }


}