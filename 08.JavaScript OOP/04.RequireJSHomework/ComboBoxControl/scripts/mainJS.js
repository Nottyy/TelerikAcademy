/// <reference path="C:\Users\Toshiba\documents\visual studio 2013\Projects\RequireJSHomework\ComboBoxControl\libs/require.js" />
(function () {
    require.config({
        paths: {
            'jquery': 'https://code.jquery.com/jquery-2.1.1.min',
            'handlebars': 'https://cdnjs.cloudflare.com/ajax/libs/handlebars.js/2.0.0-alpha.4/handlebars.min'
        }
    });

    require(['jquery', 'comboBoxMain', 'people'], function (jquery, controls, people) {
        var comboBox = controls.ComboBox(people);
        var template = $("#person-template").html();
        var comboBoxHtml = comboBox.render(template);
        $('#container').html(comboBoxHtml);
    });
}());