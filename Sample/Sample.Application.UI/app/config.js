(function() {
    var config = {
        baseUrl: "app",
        waitSeconds: 1000,
        deps: ['./main'],
        paths: {
            'require': '../lib/require/require',
            'text': '../lib/require/text',
            'jquery': '../lib/jquery/jquery-1.9.1.min',
            'durandal': '../lib/durandal/js',
            'transitions': '../lib/durandal/js/transitions',
            'plugins': '../lib/durandal/js/plugins',
            'knockout': '../lib/knockout/knockout-3.3.0'
        }
    };

    if (typeof module !== 'undefined') {
        module.exports = config;
    } else if (typeof require.config !== 'undefined') {
        requirejs.config(config);
    }

    return config;
})();