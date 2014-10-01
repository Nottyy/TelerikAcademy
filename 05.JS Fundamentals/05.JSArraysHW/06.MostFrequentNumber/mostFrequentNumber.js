function arrInitialization() {
    var arr = [1, 1, 1, 1, 2, 2, 2, 2, 4, 4, 4, 4],
        counterFrequentNumbers = 0,
        getFreqNumber = [],
        counterMaxFrequentNum = 0,
        counter = 1;

    for (var i = 0; i < arr.length; i++) {
        for (var k = 0; k < arr.length; k++) {

            if (arr[i] === arr[k]) {
                counterFrequentNumbers += 1;
            }
        }

        if (counterFrequentNumbers > counterMaxFrequentNum) {
            counterMaxFrequentNum = counterFrequentNumbers;
            getFreqNumber.length = 0;
            getFreqNumber.push(arr[i]);
            counter = 1;
        }
        else if (counterFrequentNumbers === counterMaxFrequentNum && getFreqNumber[0] !== arr[i]) {
            getFreqNumber.unshift(arr[i]);
            counter += 1;
        }

        counterFrequentNumbers = 0;
    }


    if (counter === 1) {
        console.log('The most frequent number in the array: [' + arr + '] is - '
            + getMostFrequentNumberRepresentation(counterMaxFrequentNum, getFreqNumber[0]));
    }
    else {
        var result = "";

        for (var i = counter - 1; i >= 0; i--) {
            result += getMostFrequentNumberRepresentation(counterMaxFrequentNum, getFreqNumber[i]) + ' ';
        }

        console.log('There are ' + counter + ' most frequent numbers in the array: [' + arr + '] - ' + result);
    }

}

function getMostFrequentNumberRepresentation(counterMaxFrequentNum, mostFrequentNumber) {
    var representation = "";

    for (var i = 0; i < counterMaxFrequentNum; i++) {
        representation += mostFrequentNumber + ' ';
    }

    return '{ ' + representation + '}';
}