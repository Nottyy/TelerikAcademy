function arrInitialization() {
    var arr = [11, 4, 3, 2, 10, 1, 4, 3, 1, 3, 4, 5, 111, 0];
    var smallestValueIndex;

    console.log('Inital array: ' + arr)

    for (var i = 0; i < arr.length; i++) {
        smallestValueIndex = i;

        for (var k = i + 1; k < arr.length; k++) {
            
            if (arr[k] < arr[smallestValueIndex]) {
                smallestValueIndex = k;
            }
        }

        if (smallestValueIndex !== i) {
            var tmp = arr[i];
            arr[i] = arr[smallestValueIndex];
            arr[smallestValueIndex] = tmp;
        }
    }

    console.log('Sorted array: ' + arr);
}

