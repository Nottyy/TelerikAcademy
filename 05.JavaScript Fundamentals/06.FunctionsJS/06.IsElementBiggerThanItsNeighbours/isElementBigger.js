function isElementBiggerThanItsNeighbours(array, position) {
    var isBiggerThanNeighbours = false;

    if (array[position - 1] !== undefined && array[position + 1] !== undefined) {
        if ((array[position - 1] + array[position + 1]) < array[position] ) {
            isBiggerThanNeighbours = true;
        }
    }

    console.log('The element at position - ' + position + ' in the array - ' + array + ' is bigger than its neighbours - ' + isBiggerThanNeighbours);
}