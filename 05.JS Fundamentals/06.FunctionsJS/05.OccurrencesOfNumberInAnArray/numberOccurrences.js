function numOccurrences(array, number) {
    var arrLength = array.length;
    var countOccurrences = 0;
    var workingCorrectly = false;

    for (var i = 0; i < arrLength; i++) {
        if (array[i] === number) {
            countOccurrences += 1;
        }
    }

    if (countOccurrences === 3) {
        workingCorrectly = true;
    }

    console.log('The number - ' + '"' + number + '" appears "' + countOccurrences + '" times in the array - ' + array);
    console.log('The program is working correctly - ' + workingCorrectly);
}