function findTheElement() {
    var arrayInt = [1, 2, 45, 4];
    var element = 45;
    arrayInt = arrayInt.sort(function (a, b) { return a - b });
    var start = 0;
    var middle = Math.floor(arrayInt.length / 2);
    var end = arrayInt.length - 1;
    var index = 0;

    while (true) {
        if (element < arrayInt[middle]) {
            end = middle;
            middle = Math.floor((start + end) / 2);
        }
        else if (element > arrayInt[middle]) {
            start = middle;
            middle = Math.floor((start + end) / 2);
        }
        else {
            console.log("The index of the element  " + element + " would be " + middle + " if the array was sorted!");
            break;
        }
           
        if (start == end) {
            console.log("The index of the element " + element + " would be " + start + " if the array was sorted!");
            break;
        }
        else if (element == arrayInt[start]) {
            console.log("The index of the element " + element + " would be " + start + " if the array was sorted!");
            break;
        }
        else if (element == arrayInt[end]) {
            console.log("The index of the element " + element + " would be " + end + " if the array was sorted!");
            break;
        }
    }
}