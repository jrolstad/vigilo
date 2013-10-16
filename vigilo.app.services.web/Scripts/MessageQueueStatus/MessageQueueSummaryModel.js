(function ($) {
    // register namespace
    $.extend(true, window, {
        "vigilo": {
            "messagequeuestatus": {
                "MessageQueueSummaryViewModel": MessageQueueSummaryViewModel
            }
        }
    });

    function MessageQueueSummaryViewModel(options) {
        var self = this;

        var settings = options;

        self.messageQueues = ko.observableArray([]);
        self.status = ko.observable("");
        
        self.getMessageQueueStatus = function() {
            $.ajax({
                url: settings.messageQueueSummaryApiUrl
            }).done(function(data) {

                $.each(data, function(index, element) {
                    var model = new vigilo.messagequeuestatus.MessageQueueModel();
                    model.name(element.name);
                    model.consumerCount(element.consumerCount);
                    model.messageCount(element.messageCount);
                    model.queueExists(element.queueExists);

                    var validationMessage = "";
                    $.each(element.validationResults,function(vindex, velement) {
                        validationMessage += (velement.message + ";");
                    
                    });
                   
                    model.validationMessage(validationMessage.substring(0,validationMessage.length-1));

                });
                self.messageQueues(data);


            }).error(function(err) {
                self.messageQueues([]);

            })
            .complete(function(event) {

            });
        };

        return self;

    }

})(jQuery);