$(function () {
    $("input[data-autocomplete-source]").each(function () {
        var target = $(this);
        var dataval = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.whitespace,
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: target.attr("data-autocomplete-source") + "?q=%QUERY",
                wildcard: "%QUERY"
            }
        });

        target.typeahead({ highlight: true }, {
            name: "q",
            source:dataval
        })
    });

    $('a[data-toggle="tab"]').each(function () {
        var target = $(this);
        target.click(function (e) {
            e.preventDefault();
            $(target.attr("href")).tab("show");
        });
    });

    $('[data-toggle="tooltip"]').tooltip({
        selector: '[data-toggle=tooltip',
        placement: 'right',
        animated: 'fade',
        template: '<div class="tooltip" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>',
        container: 'body',
        trigger: 'hover',
        "delay":{"show":"500","hide":"50"}
    });

    $('[data-toggle="popover"').tooltip();

    $('[data-prevent="outerscroll"]').on('mousewheel', function (e) {
        var event = e.originalEvent, d = event.wheelDelta || -event.detail;
        this.scrollTop += (d < 0 ? 1 : -1) * 30;
        e.preventDefault();
    });

});