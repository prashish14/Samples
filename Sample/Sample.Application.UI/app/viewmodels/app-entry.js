﻿define([
    'knockout'
], function (
    ko
    ) {
    'use strict';

    var appEntryViewModel = function() {
        this.name = ko.observable("Pasha");
    };

    appEntryViewModel.prototype.activate = function (settings) {

    };

    return appEntryViewModel;
});