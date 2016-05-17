$.validator.unobtrusice.adapters.addSingleVal("maxwords", "wordcount");
$.validator.addMethod("maxwords", function (value, element, maxwords) {
    if (value && value.split(" ").length > maxwords) {
        return false;
    }
    return true;
});