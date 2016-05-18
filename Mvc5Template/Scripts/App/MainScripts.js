$(function () {
    //Global Vars
    var DroppedFiles = false;

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
        selector: '[data-toggle="tooltip"]',
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



    $('[data-ajax="dragndrop"]').each(function () {
        var form = $(this);
        var dp = form.find(".box");
        if (Modernizr.draganddrop && window.FileReader) {
            var uploadLink = dp.find(".box__file_upload");
            dp.addClass("has-advanced-upload");
            dp.addClass("js");
            dp.on("drag dragstart dragend dragover dragenter dragleave drop", function (e) {
                e.preventDefault();
                e.stopPropagation();
            }).on("dragover dragenter", function () {
                dp.addClass("is-dragover");
            }).on("dragleave dragend drop", function () {
                dp.removeClass("is-dragover");
            }).on("drop", function () {
                DroppedFiles = e.originalEvent.dataTransfer.files;
                displayFiles(DroppedFiles);
            });
        }
    });

    $('[data-ajax="dragndrop"]').on("submit",function (e) {
        if (Modernizr.draganddrop && window.FileReader) {
            e.preventDefault();
            var form = $(this);
            var formName = form.attr("name");
            var dp = form.find(".box");
            if (dp.hasClass("is-uploading")) return false;
            fp.addClass("is-uploading").removeClass("is-error");

            var formData = new FormData(form);
            if (DroppedFiles) {
                $.each(DroppedFiles, function (index, file) {
                    formData.append(formName, file);
                });
            }

            $.ajax({
                url: form.attr("action"),
                type: form.attr("method"),
                data: formData,
                dataType: "json",
                beforeSend: db.find(".box__uploading_icon").show(),
                cache: false,
                contentType: false,
                processData: false
            }).done(function (data) {
                showSuccess(data.msg);
            }).fail(function (data) {
                show(data.msg, data.err_type);
            }).always(function () {
                db.find(".box__uploading_icon").hide();
            });

        }
    });

});