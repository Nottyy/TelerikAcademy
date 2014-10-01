var button = document.getElementById('btn');
button.addEventListener('click', onGenerateButtonClick);

function onGenerateButtonClick() {
    var container = document.getElementById('container');

    while (container.firstChild) {
        container.removeChild(container.firstChild);
    }

    var count = (document.getElementById('input-count').value | 0) || 20;

    if (count > 100) {
        count = 100;
    }

    var randomDivsAsDocFrag = createRandomDivs(count);
    container.appendChild(randomDivsAsDocFrag);
}

function createRandomDivs(count) {
    var docFrag = document.createDocumentFragment();

    for (var i = 0; i < count; i++) {
        var currentDiv = document.createElement('div');
        var style = currentDiv.style;

        style.width = getRandomCoordinate(30, 100) + 'px';
        style.height = getRandomCoordinate(30, 100) + 'px';
        style.background = getRandomColor();
        style.color = getRandomColor();

        style.position = 'absolute';
        style.top = getRandomCoordinate(10, 75) + '%';
        style.left = getRandomCoordinate(0, 75) + '%';

        var border = getRandomCoordinate(0, 10) + 'px' + ' solid ' + getRandomColor();
        style.border = border;
        style.borderRadius = getRandomCoordinate(0, 40) + 'px';

        currentDiv.innerHTML = '<strong>' + currentDiv.tagName + '</strong>';
        style.textAlign = 'center';

        docFrag.appendChild(currentDiv);
    }

    return docFrag;
}

function getRandomColor() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';

    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }

    return color;
}

function getRandomCoordinate(min, max) {
    return Math.random() * (max - min) + min;
}