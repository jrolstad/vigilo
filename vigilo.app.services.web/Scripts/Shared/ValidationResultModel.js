(function ($) {
    // register namespace
    $.extend(true, window, {
        "vigilo": {
            "shared": {
                "ValidationResultModel": ValidationResultModel
            }
        }
    });

    function ValidationResultModel() {
        var self = this;

        self.message = ko.observable("");
        self.severity = ko.observable("");
        self.isError = ko.observable(false);
        self.isWarning= ko.observable(false);

        return self;

    }

})(jQuery);