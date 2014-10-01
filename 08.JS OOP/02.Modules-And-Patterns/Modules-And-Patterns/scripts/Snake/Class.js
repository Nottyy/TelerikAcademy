'use strict';
var Snake = Snake || {};

Snake.Class = (function (startPositionX, startPositionY, length, speed) {

    var directionX = 1;
    var directionY = 0;
    var snakeBody = [];
    var speed = speed;
    var newSpeed;
    var speedChange = false;
    var length = length;

    (function initzializeSnakeBody() {
        snakeBody.push([startPositionX, startPositionY, directionX, directionY]);

        for (var i = 1; i < length; i++) {
            snakeBody.push([startPositionX - 14, startPositionY, 0, 0]);
        }
    }());

    function getSnakeData() {
        return snakeBody;
    }

    function update() {

        if (snakeBody[0][0] % 14 == 0 && snakeBody[0][1] % 14 == 0) {

            if (speedChange) {
                speed = newSpeed;
                speedChange = false;
            }

            for (var i = length - 1; i > 0; i--) {
                snakeBody[i][2] = snakeBody[i - 1][2];
                snakeBody[i][3] = snakeBody[i - 1][3];
            }

            snakeBody[0][2] = directionX;
            snakeBody[0][3] = directionY;
        }

        var speedX = snakeBody[0][2] * speed;
        var speedY = snakeBody[0][3] * speed;

        snakeBody[0][0] += speedX;
        snakeBody[0][1] += speedY;

        for (var i = 1; i < snakeBody.length; i++) {

            speedX = snakeBody[i][2] * speed;
            speedY = snakeBody[i][3] * speed;

            snakeBody[i][0] += speedX;
            snakeBody[i][1] += speedY;
        }
    }

    function increaseSpeed() {

        switch (speed) {

            case 1:
                newSpeed = 2;
                speedChange = true;
                break;

            case 2:
                newSpeed = 3.5;
                speedChange = true;
                break;

            case 3.5:
                newSpeed = 7;
                speedChange = true;
                break;

            default:
                newSpeed = 14;
                speedChange = true;
        }
    }

    function increaseLength() {
        snakeBody.push([snakeBody[length - 1][0] - 14 * snakeBody[length - 1][2], snakeBody[length - 1][1] - 14*snakeBody[length - 1][3], snakeBody[length - 1][2], snakeBody[length - 1][3]]);
        length++;
    }

    function moveLeft() {
        directionX = -1;
        directionY = 0;
    }

    function moveDown() {
        directionX = 0;
        directionY = 1;
    }

    function moveRight() {
        directionX = 1;
        directionY = 0;
    }

    function moveUp() {
        directionX = 0;
        directionY = -1;
    }

    return {
        moveUp: moveUp,
        moveDown: moveDown,
        moveLeft: moveLeft,
        moveRight: moveRight,
        update: update,
        increaseLength: increaseLength,
        getSnakeData: getSnakeData,
        increaseSpeed: increaseSpeed
    }
});