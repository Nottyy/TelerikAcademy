'use strict';
var Snake = Snake || {};
Snake.Engine = (function (container) {

    var COLS = 55;
    var ROWS = 30;
    var WIDTH = 770;
    var HEIGHT = 462;
    var CONTAINER = container;

    var drawer = Snake.drawer;
    var snakeScore = new Snake.Score(WIDTH, HEIGHT);
    var snake;

    var stones;
    var appleItervalID;
    var score;
    var level;
    var pauseFlag = false;
    var animationFrameID;

    var stage;
    var snakeLayer = new Kinetic.Layer();
    var backgroundLayer = new Kinetic.Layer();
    var snakeHeadLayer = new Kinetic.Layer();
    var appleLayer = new Kinetic.Layer();

    (function setControls() {
        document.addEventListener('keydown', function (ev) {
            switch (ev.keyCode) {
                case 37:
                    snake.moveLeft();
                    break;
                case 38:
                    snake.moveUp();
                    break;
                case 39:
                    snake.moveRight();
                    break;
                case 40:
                    snake.moveDown();
                    break;
                case 19:
                case 80:
                    togglePauseGame();
                    break;
                default:
            }
        });
    }());

    function startGame() {

        stones = [];
        snake = new Snake.Class(28, 15 * 14, 10, 1);
        score = 0;
        level = 1;

        window.clearInterval(appleItervalID);

        backgroundLayer.destroy();
        snakeHeadLayer.destroy();
        drawer.snakeDestroy();

        stage = new Kinetic.Stage({
            container: CONTAINER,
            width: WIDTH,
            height: HEIGHT
        });

        setGameFieldSize();
        generateStones(stones);
        drawBackground(backgroundLayer, stones);
        updateScore();
        animationFrameID = window.requestAnimationFrame(frame);
        appleItervalID = window.setInterval(randomApple, 2000);
    }

    function frame() {
        snake.update();
        var snakeBody = snake.getSnakeData();
        drawer.snake(cell, snakeBody[0][0], snakeBody[0][1], snakeHeadLayer)

        for (var cell = 1; cell < snakeBody.length; cell++) {
            drawer.snake(cell, snakeBody[cell][0], snakeBody[cell][1], snakeLayer)
        }

        if (!hasCollision(snakeBody)) {
            stage.add(snakeLayer);
            stage.add(snakeHeadLayer);
            animationFrameID = window.requestAnimationFrame(frame);
        }
    }

    function randomApple() {
        drawer.apple(random(1, COLS - 1), random(1, ROWS - 1), appleLayer);
        stage.add(appleLayer);
        window.clearInterval(appleItervalID);
        appleItervalID = window.setInterval(randomApple, 10000);
    }

    function hasCollision(snakeBody) {
        var collision = backgroundLayer.getIntersection({
            x: snakeBody[0][0] + 7,
            y: snakeBody[0][1] + 7
        });

        if (collision) collision = collision.getName();

        if (collision == 'stone' || collision == 'border') {
            finishGame();
            return true;
        }

        collision = snakeLayer.getIntersection({
            x: snakeBody[0][0] + 7 + 6 * snakeBody[0][2],
            y: snakeBody[0][1] + 7 + 6 * snakeBody[0][3]
        });

        if (collision) collision = collision.getName();

        if (collision == 'snake') {
            finishGame();
            return true;
        }

        collision = appleLayer.getIntersection({
            x: snakeBody[0][0],
            y: snakeBody[0][1]
        });

        if (collision) collision = collision.getName();

        if (collision == 'apple') {
            randomApple();
            snake.increaseLength();
            score += 10;
            updateScore();
        }

        return false;
    }

    function finishGame() {
        setTimeout(startGame, 3000);
        snakeScore.gameOver(level, backgroundLayer, stage);
    }

    function updateScore() {

        if (score > 0 && (score % (10 * level * level)) == 0) {
            level++;
            snake.increaseSpeed();
        }

        snakeScore.result(score, appleLayer, stage);
        snakeScore.level(level, appleLayer, stage);
    }

    function togglePauseGame() {

        if (!pauseFlag) {
            window.cancelAnimationFrame(animationFrameID)
            window.clearInterval(appleItervalID);
        }
        else {
            animationFrameID = window.requestAnimationFrame(frame);
            appleItervalID = window.setInterval(randomApple, 10000);
        }
        pauseFlag = !pauseFlag;
    }

    function drawBackground(layer) {

        for (var i = 0; i < ROWS; i++) {
            drawer.border(0, i, layer);
            drawer.border(COLS - 1, i, layer);
        }

        for (var i = 0; i < COLS; i++) {
            drawer.border(i, ROWS - 1, layer);
            drawer.border(i, 0, layer);
        }

        for (var i = 0; i < stones.length; i++) {
            drawer.stone(stones[i][0], stones[i][1], layer);
        }

        stage.add(layer);
    }

    function generateStones(stones) {
        var numberOfStones = random(10, 15);

        for (var i = 0; i < numberOfStones; i++) {
            stones.push([random(1, COLS - 1), random(1, ROWS - 1)]);
        }
    }

    function random(from, to) {
        return (Math.random() * (to - from) + from) | 0
    }

    function setGameFieldSize() {
        var container = document.getElementById(CONTAINER)

        if (window.innerWidth / window.innerHeight < WIDTH / HEIGHT) {
            container.style.zoom = window.innerWidth / WIDTH;
        }
        else {
            container.style.zoom = window.innerHeight / (HEIGHT + 4);

        }

        container.style.backgroundColor = 'darkgreen';
        container.style.display = 'inline-block';
        document.body.style.overflow = 'hiden';
    }

    return {
        startGame: startGame
    }
});