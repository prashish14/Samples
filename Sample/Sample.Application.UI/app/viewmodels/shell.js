define([
    'knockout',
    'plugins/router'
], function (ko, router) {
    'use strict';

    return {
        router: router,
        activate: function () {
            router.map([
                { route: ['', 'appEntry/'], title: 'Welcome', moduleId: 'viewmodels/app-entry' }
            ]);
            
            router.activate();
        }
    };
});