define([
    'durandal/system',
    'durandal/app',
    'durandal/viewLocator',
    'plugins/widget'
], function (
    system,
    app,
    viewLocator,
    widgetPlugin
    ) {
    'use strict';

    system.debug(true);
    app.title = 'Sample';
    app.configurePlugins({
        router: true,
        widget: true
    });

    app.start().then(function() {
        viewLocator.useConvention();

        widgetPlugin.convertKindToModulePath = function (kind) {
            return 'widgets/' + kind + '/viewModel';
        };
        widgetPlugin.convertKindToViewPath = function (kind) {
            return 'widgets/' + kind + '/view.html';
        };

        app.setRoot('viewmodels/shell');
    });
});