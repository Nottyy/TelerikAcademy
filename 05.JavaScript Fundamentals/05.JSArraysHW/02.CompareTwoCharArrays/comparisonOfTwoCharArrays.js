function arrInitialization() {
    var arrOne = ['b', 'c', 'd', 'f'];
    var arrTwo = ['b', 'c', 'd', 'e'];
    var arrOneLength = arrOne.length,
        arrTwoLength = arrTwo.length,
        areArraysEqual = true; // Assume the two arrays are equal by default

    // Compare the lengths for the two arrays
    if (arrOneLength == arrTwoLength) {
        // The two arrays have same lengths
        for (var i = 0; i < arrOneLength; i++) {
            if (arrOne[i] !== arrTwo[i]) {
                areArraysEqual = false;
                break;
            }
        }
    } else {
        // The two arrays have different lengths
        areArraysEqual = false;
    }

    console.log("Is array [" + arrOne + "] equal to array [" + arrTwo + "] ? // " + areArraysEqual);
}