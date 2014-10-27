function flyingCircle() {
    var canvas = document.getElementById('the-canvas');
    var ctx = canvas.getContext('2d');

    ctx.strokeStyle = '#000000';
    ctx.lineWidth = 2;

    var x = 150,
        y = 150,
        radius = 10,
        from = 0,
        to = 2 * Math.PI,
        updateX = 5,
        updateY = -5;

    function createBall(x, y, radius, from, to) {
        ctx.beginPath();
        ctx.arc(x, y, radius, from, to);
        ctx.stroke();
    }

    function moveBall() {
        ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height); // clear ball path
        ctx.strokeRect(50, 50, 500, 300);
        createBall(x, y, radius, from, to);

        if (x + radius <= 70) {
            updateX = 5;
        }
        if (x + radius >= 550) {
            updateX = -5;
        }
        if (y + radius <= 70) {
            updateY = 5;
        }
        if (y + radius >= 350) {
            updateY = -5;
        }

        x += updateX;
        y += updateY;
        requestAnimationFrame(moveBall);
    }

    requestAnimationFrame(moveBall);
}