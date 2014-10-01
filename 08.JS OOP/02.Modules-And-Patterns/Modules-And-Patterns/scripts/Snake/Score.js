/// <reference path="C:\Users\Ivan\Desktop\github\JS\Modules-And-Patterns\Modules-And-Patterns\libs/kinetic-v5.1.0.js" />
'use strict';
var Snake = Snake || {};
Snake.Score = (function (width, height) {

    var resultKJS,
        levelKJS,
        gameOverKJS;

    (function setKJSContainers() {
        resultKJS = new Kinetic.Text({
            x: width * 3 / 5,
            y: height - 35,
            fontSize: 24,
            fontFamily: 'Calibri',
            fill: 'white'
        });

        levelKJS = new Kinetic.Text({
            x: width * 1 / 4,
            y: height - 35,
            fontSize: 24,
            fontFamily: 'Calibri',
            fill: 'white'
        });

        gameOverKJS = new Kinetic.Text({
            x: width / 10,
            y: height / 4,
            fontSize: 122,
            text: 'GAME OVER',
            fontFamily: 'Calibri',
            fill: 'red'
        });
    }());

    function gameOver(score, layer, stage) {
        layer.add(gameOverKJS);
        stage.add(layer);
    }

    function result(score, layer, stage) {
        resultKJS.setText('Score: ' + score);
        layer.add(resultKJS);
        stage.add(layer);
    }

    function level(level, layer, stage) {
        levelKJS.setText('Level: ' + level);
        layer.add(levelKJS);
        stage.add(layer);
    }

    return {
        result: result,
        level: level,
        gameOver: gameOver
    }
});