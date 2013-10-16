(function ($) {
    // register namespace
    $.extend(true, window, {
        "vigilo": {
            "messagequeuestatus": {
                "MessageQueueModel": MessageQueueModel
            }
        }
    });

    function MessageQueueModel() {
        var self = this;

        self.name = ko.observable("");
        self.messageCount = ko.observable(0);
        self.consumerCount = ko.observable(0);
        self.queueExists = ko.observable(true);
        self.validationResults = ko.observable("");

        return self;

    }

})(jQuery);