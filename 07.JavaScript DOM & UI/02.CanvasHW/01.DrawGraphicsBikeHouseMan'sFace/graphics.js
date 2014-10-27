function createHouseBikeMan() {
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');
    ctx.save();
    canvas.style.background = "#444";

    createMan();
    createHouse();
    createBike();

    function createEllipse(x, y, radius, startAngle, endAngle, strokeStyle, fillStyle, scaleX, scaleY) {
        ctx.beginPath();
        ctx.save();

        if (scaleX != undefined || scaleY != undefined) {
            ctx.scale(scaleX, scaleY);
        }

        ctx.arc(x, y, radius, startAngle, endAngle);

        if (fillStyle != undefined) {
            ctx.fillStyle = fillStyle;
            ctx.fill();
        }
        if (strokeStyle != undefined) {
            ctx.strokeStyle = strokeStyle;
            ctx.stroke();
        }

        ctx.restore();
    }

    function createLine(fromX, fromY, toX, toY, strokeColor) {
        ctx.save();

        ctx.moveTo(fromX, fromY);
        ctx.strokeStyle = strokeColor;
        ctx.lineTo(toX, toY);

        ctx.stroke();

        ctx.restore();
    }

    function createMan() {
        // create head
        ctx.lineWidth = 2;
        createEllipse(100, 200, 50, 1.8 * Math.PI, 1.2 * Math.PI, '#3B889A', '#90CAD7');
        createEllipse(45, 186, 5, 0, 2 * Math.PI, '#3B889A', '#90CAD7', 1.5, 1);
        createEllipse(69, 186, 5, 0, 2 * Math.PI, '#3B889A', '#90CAD7', 1.5, 1);
        createEllipse(64, 124, 2, 0, 2 * Math.PI, '#3B889A', '#3B889A', 1, 1.5);
        createEllipse(100, 124, 2, 0, 2 * Math.PI, '#3B889A', '#3B889A', 1, 1.5);
        createLine(77, 215, 87, 190, '#3B889A');
        createLine(77, 215, 87, 215, '#3B889A')
        ctx.rotate(9 * Math.PI / 180);
        ctx.lineWidth = 1;
        createEllipse(40, 215, 6.5, 0, 2 * Math.PI, '#3B889A', '#90CAD7', 3, 1);

        // create hat
        ctx.restore();
        ctx.save();
        createEllipse(16, 165, 9, 1.70 * Math.PI, 1.34 * Math.PI, '#000000', '#396693', 6, 1);

        ctx.beginPath();
        ctx.moveTo(68, 158);
        ctx.lineTo(68, 88);
        ctx.lineTo(131, 88);
        ctx.lineTo(131, 158);
        ctx.closePath();

        ctx.fillStyle = '#396693';
        ctx.fill();
        ctx.lineWidth = 2;
        ctx.stroke();

        ctx.restore();
        createEllipse(25, 157, 8, 0, Math.PI, '#000000', '#396693', 4, 1);
        createEllipse(25, 88, 8, 0, 2 * Math.PI, '#000000', '#396693', 4, 1);
    }

    function createHouse() {
        ctx.save();

        createRoof();
        createChimney();
        createFundamentals();
        createWindows();
        createDoor();

        function createRoof() {

            ctx.beginPath();
            ctx.lineWidth = 3;
            ctx.moveTo(300, 200);
            ctx.lineTo(550, 200);
            ctx.lineTo(425, 80);

            ctx.closePath();
            ctx.stroke();
            ctx.fillStyle = '975B5B';
            ctx.fill();

        }

        function createChimney() {
            ctx.beginPath();
            ctx.lineWidth = 2;

            ctx.moveTo(475, 170);
            ctx.lineTo(475, 100);
            ctx.lineTo(495, 100);
            ctx.lineTo(495, 170);
            ctx.fill();
            ctx.stroke();
            ctx.closePath();

            ctx.lineWidth = 1;
            createEllipse(121.3, 100, 2.5, 0, 2 * Math.PI, '000000', '975B5B', 4, 1);
        }

        function createFundamentals() {
            ctx.beginPath();
            ctx.lineWidth = 2;
            ctx.moveTo(298, 202);
            ctx.lineTo(300, 400);
            ctx.lineTo(550, 402);
            ctx.lineTo(552, 202);
            ctx.fill();
            ctx.stroke();
        }

        function createWindows() {
            ctx.beginPath();
            ctx.fillStyle = 'black';
            ctx.strokeStyle = '975B5B';
            ctx.lineWidth = 2;

            // window 1
            ctx.fillRect(320, 220, 90, 60);
            ctx.moveTo(320, 250);
            ctx.lineTo(410, 250);
            ctx.moveTo(365, 220);
            ctx.lineTo(365, 280);

            // window 2
            ctx.fillRect(440, 220, 90, 60);
            ctx.moveTo(440, 250);
            ctx.lineTo(530, 250);
            ctx.moveTo(485, 220);
            ctx.lineTo(485, 280);

            // window 3
            ctx.fillRect(440, 310, 90, 60);
            ctx.moveTo(440, 340);
            ctx.lineTo(530, 340);
            ctx.moveTo(485, 310);
            ctx.lineTo(485, 370);

            ctx.stroke();

            ctx.closePath();
        }

        function createDoor() {
            ctx.beginPath();
            ctx.strokeStyle = '#000000';
            ctx.moveTo(320, 400);
            ctx.lineTo(320, 320);

            ctx.moveTo(350, 400);
            ctx.lineTo(350, 310);

            ctx.moveTo(380, 400);
            ctx.lineTo(380, 320);

            ctx.moveTo(320, 320);
            ctx.quadraticCurveTo(350, 300, 380, 320);
            ctx.stroke();
            ctx.lineWidth = 2;
            createEllipse(340, 370, 5, 0, 2 * Math.PI, '000000', '975B5B');
            createEllipse(360, 370, 5, 0, 2 * Math.PI, '000000', '975B5B');
        }
    }

    function createBike() {
        ctx.strokeStyle = '#3B889A';

        //wheels
        createEllipse(50, 400, 50, 0, 2 * Math.PI, '#3B889A', '#90CAD7');
        createEllipse(245, 400, 50, 0, 2 * Math.PI, '#3B889A', '#90CAD7');

        //frame
        ctx.beginPath();
        ctx.moveTo(50, 400);
        ctx.lineTo(90, 330);
        ctx.lineTo(140, 400);
        ctx.closePath();

        ctx.moveTo(90, 330);
        ctx.lineTo(230, 330);
        ctx.lineTo(140, 400);

        ctx.moveTo(245, 400);
        ctx.lineTo(223, 280);
        ctx.lineTo(250, 250);
        ctx.moveTo(223, 280);
        ctx.lineTo(185, 290);

        ctx.moveTo(90, 330);
        ctx.lineTo(80, 310);
        ctx.moveTo(65, 310);
        ctx.lineTo(95, 310);

        ctx.stroke();

        createEllipse(140, 400, 10, 0, 2 * Math.PI, '#3B889A');
        ctx.moveTo(132, 395);
        ctx.lineTo(115, 380);
        ctx.moveTo(148, 405);
        ctx.lineTo(165, 420);
        ctx.stroke();
    }
}