define([
    'knockout'
], function (
    ko
    ) {
    'use strict';

    var appEntryViewModel = function () {
        var self = this;

        self.name = ko.observable("Pasha");
        self.lastName = ko.observable("Kaliukhovich");
        self.age = ko.observable(22);
        self.contacts = ko.observable("");
    };

    appEntryViewModel.prototype.activate = function (settings) {

    };

    return appEntryViewModel;
});