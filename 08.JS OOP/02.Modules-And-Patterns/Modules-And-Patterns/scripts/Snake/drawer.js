'use strict';
var Snake = Snake || {};

Snake.drawer = (function () {

    var CELL_SIZE = 14;

    var appleImg = new Image();
    var borderImg = new Image();
    var stoneImg = new Image();
    var snakeImg = new Image();

    var appleKJS;
    var stoneKJS;
    var borderKJS;
    var snakeKJS;
    var snakeCells = [];

    (function setSources() {
        appleImg.src = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAMAAAAolt3jAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAMAUExURQAAAAsVDR4YFRUvCxMlEiIaDyQZCywUGjIAADYEATYCCDwAADgNAzcYCTwcDj4eDjAYET8ZEiMqHDwhHjosGSkrICo9JiRJHDdTGyNkBjdtHjpxHkMHAUYFBUkMB0cKEUMTCUAbC08SEFYLAVYXHEshD14iH00xJ2QICGoODGESB2EREWASEHAjDWskNXkmNHAxLXcxN30wPn00PHo7NGE2RnwzQVZbMEN0LEt1JFx0JFt5IlB/MXVBN3JIOUBPRocUCIMZEJ0ZGZAgHpkmF4YoIo8kL5c0JJg1Ka0cELMWBK4uB7MhBLEvGaknMqk0IYBCNr1TWrJnX6V2ZcMcEN4bDd8WLNseKd8gCd8kD9wpHd46Fd05GdQlKd8kJNopIt0pKtU0ItkwJN40Jdo2Ktg4J9k4KNkzO90+MeMbEegdEe8dFusfHfIfB/YYCfIXE/QaGuYSJ+IeLukbM/UbLf8ZIP8cLvMUOf8XPv8ZNeYrAOQsAO4iAO0kBeMhFOImEeYgGOAoF+olF+gnFekvF+gvHO4oGuUyAOs3B+o1EPIuA/AjGfYnGvQqFP8hF/0kF+AkJeMsJecvI+slIekoJ+8tL+4pNOMwK+45OvIhJ/MnIv8kIMZCNtlCNtRTQsFvW+lQSO1aTOxTV+5dVPFSWv9VVPdTZvVYc/hUcuhmSPV2WuV9ZpP2N7r/Xa3/YQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFH9zOoAAAEAdFJOU////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wBT9wclAAAACXBIWXMAAA7DAAAOwwHHb6hkAAAAFnRFWHRTb2Z0d2FyZQBwYWludC5uZXQgNC4wO+j1aQAAANNJREFUGFdj+A8GYuJSktIS//+DuGxMQiwW69astbEHcVUDbNUZmS2trcxFgVwFj5Wr5guzm+rpBwWLMAi6pkW2zFNTCVy0dMFqOwalOQ19/SGODl69eZkLDRh0MrLzcyamRnd01YQuMWTQTO6eNSEhvrOquj1quRmDRlJb06S4aTMLeprDVxgxaM9tjKifUlxeUVkStsyYQc4/sbVualFhWensyYtNGHiVfVOmx6bPyMqtjXFXZPjPp+Xi5Ofm7OnjrSsAciQ/J7c8F4esDA/r//8AJ5JRZI7zGswAAAAASUVORK5CYII=";

        snakeImg.src = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAMAAAAolt3jAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAMAUExURQAAAAwXAg8cBRMgAxknCR0qAxwsAB4pCR8kESEuCSMnFSQuFiAyASIwBiQzACQ3BCQwDyQ0CCs4CCw6CiUxEC48GzM7FS88IDQ9KjpMCTtUAT1RFTtCIT5MJEFCJ15vNV9xNWd9Cm1+Jm5/LWBxNmJxPGd5PWh3O3aLHXaKKnGDMHODN3SFNHqKRYGYMoShDY+sD42lEJGrB5OvBZCoG5KyCZy1HpWtJZq0KaG5N4ycSpirRqLDAKHCAqHABKLCBaPCBqPEAKPHAKXCBKTGAKXFBafHB6fGCaXLAKnGCqrED6nKAKvJBKjIBanIBqvIB6rMAavOAavNBqzKAazKA63IBqzKB63MAKzNAa3OAK7PAa7OBKvICKnKCKzKCK3KCa7LCq/OCK/OCq/OD6bAEajDHKvHHavMEK7JE6zLEqvQAK7RAK7QAq7SAK3SBK/UArHNBLHOBrHMCLPMF7TNFbHPGrDQArDSALHQBbPVALHXALPUBrbXAbTUB7PSCrDRDLDSDLTYArfYBL/cDrTUFLLRGLXSGrXVHbjVEq/LI67MJrXPO7bUJrnVIrvVLr7VKbnVMrXMRsbfOcDjCMvoKdbsLdHnPtbsONb1IMjZSsrfScbTV8viTcziTtLnRdPsTtDnUNv0Uuj/VPD/UAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAKbjveoAAAEAdFJOU////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wBT9wclAAAACXBIWXMAAA7DAAAOwwHHb6hkAAAAFnRFWHRTb2Z0d2FyZQBwYWludC5uZXQgNC4wO+j1aQAAANRJREFUGFdj+P//v7iKmryCqrookAnkyurNXzBn7sJFE8VAXG7NKbHOGV7Rk2fMlPvPIKHUW+li11EUnp09dbYMg3BfdFajW0xBZLl38GIrBqG0PI/8JpuIGpeK5ulaDOypuVVOkZWB1Ykhof3KDAITcsoDHMu8fQr9S6bpMIh0p7sEJbvHh/klFM/TZmCx7LJtaHHwrKuNS5mlyyAobdFe79ra5huVNMmai+E/k6SBaWlPZ6a9sQYHyJECUvqGJuZmRoqMYDf/5+FnY+Xk5WP+//8/ACnATxEBRBpjAAAAAElFTkSuQmCC';

        stoneImg.src = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAMAAAAolt3jAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAMAUExURQAAAFE5X1s1cGQyeWlSfnBXd3lfeXhwd1w1iGE7hWg8i3EtnHM9iXIzl3s/km85qXcirn8ovXM4pHI9rn80ong1rnw9yGlCimlNhWpShWtYiHdLmXRfgXlfhnlHr31ItHdSp31UrHdlg31zhoFgf4FodItndItzb4Q3tYAhx4QyzYY9zo01y4c92Y402Yo60JQ03JU+2ZQ834st44k55ZAw55Q974BTgYRPpZpGvolqg4B1jYx3iY97hop7lpxqiphskpZwg5F/iptrrJNhtpZ8o6F4t4tG1ZVCyJtbyMV/45qLiJqdkY+App6MoaOenLKsq7CPwriF2cSB5tWE7duf/sq0zNGq3Nug29u22tql5eCf4eWq1uKt8+mi+QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOd+GRsAAAEAdFJOU////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wBT9wclAAAACXBIWXMAAA7DAAAOwwHHb6hkAAAAFnRFWHRTb2Z0d2FyZQBwYWludC5uZXQgNC4wO+j1aQAAAI9JREFUGFdj+A8GPhDqP5TrHwChIVx2PxswDeUyBkaqghlgroy4S6yDN5zLKS/qFaEG40oIu2t5xNnDuBxiJsaaITHqEK4dv66ZqYFltCOEy6VvZCgooBEcZQXiKgnp6Yjw8fB6hjrbArksctrc5v//qzBbBIX/Z1CWVFB0BRnKxiTtFsZgLeUL4oCALKsTAGHqdwyhb4TnAAAAAElFTkSuQmCC';

        borderImg.src = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAMAAAAolt3jAAACTFBMVEU+GQlGDQtBGAlFGQlFGQpPFA1SGQNZEQtPIw5PKw1DIBVHIhNAIxpTIwBVIQ5SKw9aJAJeJQZcJwVQJBJYJhJbKxdeLRNfLBRaKh1ZLhtNMitRNSFhGQpnGAxpGwljKAtjLw9vJgtoLQxjIxVgLxFnNg9oMh9qOBZwLw51KxFxMA1xPx5gLiFiLiNuNyxrPSV0PyFrQh9vTCd8TjNxUCKANRSHPBGOShiFVB2IUR2RRQyTRReSQxiWUBOcURafUByHSS+HUyeJVSKKUy+JWCWKUzKPWjKUViqZZB6TYSORYCWRYimSYzOUYTOXbTiebzSecCqfdSuYcj6fej+gTROqVA2rXgehWx6gXxqxXgysaBSubRSsbhavbh2schy0Ygq1Zw29bwK5bAu/bAiyZhG1aBezahixbhy1ahq7YhC/bhK7ahq9bx+zch+5chm7cxy6cx++dhykYy6raiyibjambzChciavdSSocSinczauczarcDitdziofTuyYCuwbSm5ZiO+bCG1dCy5cSCwczWwcjy0fje3eDu4czC7eDCJWkCCZ0bGZwfAYgvBZwrDaADBawbCbADCbgbEbwDBaQvCbgnGbg7Fbw/DaBTDbBPDcwDHcQrFfxrKdRDPeRrDaSHCbSbEbSHEbCPCcSLAcSXAcSbBdy3JciXEcTXBezPAfTDSeSLdfzHEfFS6gRW6giKwgTO2ijO4jD2lhEWsgELUghnWgxzPgC7NgzjAkDbRhCvZgy3VkzThhCfrjSbHk1TZiUXQoE7mi0ntq0NUl06PAAAA40lEQVR4XgUAg3EDAPBj27ZT27Zt27Zt27ZtL9aDw6H6+45R9sDJ/tHW3hV49Da0aLiy5NS+wuLqdKDSwkzmQRcGJbgxJpoOoTZy5XDNupO1OjyOYAmXfyrXjfnFx1dvC5LgAnI9HeJ3lmYXsr4xzIwy+JC6HXdm5+StvIkTV2fg0+C+3Z2yOTlxLklYm4MHhWNBec9uyfIvzusgH774uvbW/rouo9YOH9EGQpF9bGRUCM/K9m6MTAQ/DqCRKKx+5D3tNCgAnmp9fP0DEUml01PjZ8+QeX178/LDcm4qqqqsaP4Hu41Kpx9wMZAAAAAASUVORK5CYII=';

        appleKJS = new Kinetic.Image({
            name: 'apple',
            image: appleImg,
            width: 14,
            height: 14
        });

        borderKJS = new Kinetic.Image({
            name: 'border',
            image: borderImg,
            width: 14,
            height: 14
        });

        stoneKJS = new Kinetic.Image({
            name: 'stone',
            image: stoneImg,
            width: 14,
            height: 14
        });

        snakeKJS = new Kinetic.Image({
            name: 'snake',
            image: snakeImg,
            width: 14,
            height: 14
        });
    }());

    function border(x, y, layer) {
        borderKJS.setX(x * CELL_SIZE);
        borderKJS.setY(y * CELL_SIZE);
        layer.add(borderKJS.clone());
    }

    function stone(x, y, layer) {
        stoneKJS.setX(x * CELL_SIZE);
        stoneKJS.setY(y * CELL_SIZE);
        layer.add(stoneKJS.clone());
    }

    function apple(x, y, layer) {
        appleKJS.setX(x * CELL_SIZE);
        appleKJS.setY(y * CELL_SIZE);
        layer.add(appleKJS);
    }

    function snake(cell, x, y, layer) {

        if (!snakeCells[cell]) {
            snakeCells[cell] = snakeKJS.clone();
        }

        snakeCells[cell].setX(x);
        snakeCells[cell].setY(y);
        layer.add(snakeCells[cell]);
    }

    function snakeDestroy() {

        for (var i = 1; i < snakeCells.length; i++) {
            snakeCells[i].destroy();
        }

        snakeCells = [];
    }

    return {
        apple: apple,
        border: border,
        stone: stone,
        snake: snake,
        snakeDestroy:snakeDestroy
    }

})();