/// <reference path="c:\users\toshiba\documents\visual studio 2013\Projects\RequireJSHomework\ComboBoxControl\libs/jquery-2.1.1.js" />
/// <reference path="c:\users\toshiba\documents\visual studio 2013\Projects\RequireJSHomework\ComboBoxControl\libs/handlebars.min.js" />

define(['jquery', 'handlebars'], function () {
    var ComboBox = function (people) {
        function render(template) {
            var $container = $('<div>').addClass('comboBox-control');
            var compiledTemplate = Handlebars.compile(template);

            people.forEach(function (person) {
                $(compiledTemplate(person)).appendTo($container);
            })

            var hidden = 'hidden';
            var visible = 'visible';
            var selected = 'selected';

            $container.addClass(hidden);
            $container.children().first().addClass(selected);

            $container.on('click', '.person-item', function () {
                var $self = $(this);

                if ($container.hasClass(hidden)) {
                    $container.children().addClass(visible)
                    $container.removeClass(hidden);
                }
                else {
                    $container.children().removeClass(visible);
                    $container.find('.' + selected).removeClass(selected);
                    $container.addClass(hidden);
                    $self.addClass(selected);
                }
            });

            return $container;
        };

        return {
            render: render
        }
    };

    return {
        ComboBox: ComboBox
    }
});