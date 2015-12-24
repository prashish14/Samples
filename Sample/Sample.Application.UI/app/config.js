(function() {
    var config = {
        baseUrl: "app",
        waitSeconds: 1000,
        deps: ['./main'],
        paths: {
            'jquery': '../lib/jquery/jquery-1.9.1.min',
            'require': '../lib/require/require',
            'durandal': '../lib/durandal/js',
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