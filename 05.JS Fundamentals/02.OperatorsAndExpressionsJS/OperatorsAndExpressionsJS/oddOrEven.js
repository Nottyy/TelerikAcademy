
function onFindBiggerButtonClick() {
    var first = parseInt(document.getElementById('tb-first').value);

    if (first % 2 == 0) {
        console.log("number: " + first + " is even");
    }
    else {
        console.log("number: " + first + " is odd");
    }
}
