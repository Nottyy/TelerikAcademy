var Rect = (function () {
    function Rect(x, y, width, height, fillColor, strokeColor) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.fillStyle = fillColor;
        this.strokeStyle = strokeColor;
    }
    Rect.prototype = {
        draw: function (ctx) {
            ctx.beginPath();
            ctx.rect(this.x, this.y, this.width, this.height);
            ctx.fillStyle = this.fillStyle;
            ctx.strokeStyle = this.strokeStyle;
            ctx.closePath();
            ctx.fill();
            ctx.stroke();
            return this;
        }
    }

    return Rect;
}());

var Circle = (function () {
    function Circle(x, y, radius, fillColor) {
        this.x = x;
        this.y = y;
        this.radius = radius;
        this.fillStyle = fillColor;
    }
    Circle.prototype = {
        draw: function (ctx) {
            ctx.beginPath();
            ctx.arc(this.x, this.y, this.radius, 0, Math.PI * 2, true);
            ctx.fillStyle = this.fillStyle;
            ctx.closePath();
            ctx.fill();
            return this;
        }
    }

    return Circle;
}());

var Line = (function () {
    function Line(startX, startY, endX, endY, strokeColor) {
        this.startX = startX;
        this.startY = startY;
        this.endX = endX;
        this.endY = endY;
        this.strokeStyle = strokeColor;
    }
    Line.prototype = {
        draw: function (ctx) {
            ctx.beginPath();
            ctx.moveTo(this.startX, this.startY);
            ctx.lineTo(this.endX, this.endY);
            ctx.closePath();
            ctx.strokeStyle = this.strokeStyle;
            ctx.stroke();
            return this;
        }
    }

    return Line;
}());

var drawingModule = (function () {
    var canvas = document.createElement('canvas');
    canvas.width = 530;
    canvas.height = 250;
    var ctx = canvas.getContext('2d');
    document.body.appendChild(canvas);

    function drawRect(x, y, width, height, fillColor, strokeColor) {
        var newRect = new Rect(x, y, width, height, fillColor, strokeColor).draw(ctx);
    }

    function drawCircle(x, y, radius, fillColor) {
        var newCircle = new Circle(x, y, radius, fillColor).draw(ctx);
    }

    function drawLine(startX, startY, endX, endY, strokeColor) {
        var newLine = new Line(startX, startY, endX, endY, strokeColor).draw(ctx);
    }

    return {
        drawRect: drawRect,
        drawCircle: drawCircle,
        drawLine: drawLine
    }
}());