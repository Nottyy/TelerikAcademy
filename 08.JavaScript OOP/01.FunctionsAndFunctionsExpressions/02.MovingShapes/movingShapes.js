var movingShapes = (function () {
    function addShape(shape) {
        var div = document.createElement('div');
        
        div.innerHTML += '<strong> DIV </strong>';

        div.style.width = 50 + 'px';
        div.style.height = 50 + 'px';
        div.style.background = getRandomColor();
        div.style.color = getRandomColor();
        div.style.border = getRandomNumber(1, 10) + 'px' + ' solid ' + getRandomColor();
        div.style.borderRadius = getRandomNumber(0, 100) + 'px';

        div.style.position = 'absolute';

        var wrapper = document.getElementById('wrapper');
        wrapper.appendChild(div);

        if (shape == 'ellipse') {
            var centerX = 200;
            var centerY = 200;
            var radius = 150;

            var angle = 0;

            var functionTimer = setInterval(function moveDivs() {
                angle++;
                if (angle === 360) {
                    angle = 0;
                }

                var left = centerX + Math.cos((2 * 3.14 / 180) * (angle)) * radius;
                var right = centerY + Math.sin((2 * 3.14 / 180) * (angle)) * radius;

                div.style.left = left + 'px';
                div.style.top = right + 'px';
            }, 30);
        }
        else {
            var centerX = 600;
            var centerY = 100;
            var direction = 0;

            var functionTimer = setInterval(function moveDivs() {
                if (direction > 3) {
                    direction = 0;
                }

                switch (direction) {
                    case 0: centerX += 5;
                        if (centerX > 800) {
                            direction++;
                        }
                        break;
                    case 1: centerY += 5;
                        if (centerY > 400) {
                            direction++;
                        }
                        break;
                    case 2: centerX -= 5;
                        if (centerX < 500) {
                            direction++;
                        }
                        break;
                    case 3: centerY -= 5;
                        if (centerY < 100) {
                            direction++;
                        }
                        break;
                }

                div.style.left = centerX + 'px';
                div.style.top = centerY + 'px';
            }, 50);
        }
    }

    function getRandomNumber(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function getRandomColor() {
        var red = Math.floor(Math.random() * 256);
        var green = Math.floor(Math.random() * 256);
        var blue = Math.floor(Math.random() * 256);

        return 'rgb(' + red + ',' + green + ',' + blue + ')';
    }

    return {
        add: addShape
    }
}());