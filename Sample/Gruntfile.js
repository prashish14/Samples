module.exports = function (grunt) {
    var settings = grunt.file.readJSON('settings.json');

    var uiRoot = '<%= settings.UI %>/';
    var uiDestDev = '<%= settings.dev.root %>/' + '<%= settings.ClientFolder %>/';
    var uiDestProd = '<%= settings.prod.root %>/' + '<%= settings.ClientFolder %>/';
    var intdexHtmlFile = 'index.html';
    var cssFile = 'styles.css';

    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-concat-css');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-less');
    grunt.loadNpmTasks('grunt-html-build');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-durandal');
    grunt.loadNpmTasks('grunt-contrib-requirejs');
    grunt.loadNpmTasks('grunt-folder-list');
    grunt.loadNpmTasks('grunt-contrib-compress');

    var buildConfig = function () {
        var config = {
            pkg: grunt.file.readJSON('package.json'),
            settings: settings,
            clean: {
                force: true,
                dev: [uiDestDev],
                prod: [uiDestProd]
            },
            copy: {
                dev: {
                    files: [
                        {
                            expand: true,
                            cwd: uiRoot,
                            src: ['app/**/*'],
                            dest: uiDestDev
                        },
                        {
                            expand: true,
                            cwd: uiRoot,
                            src: ['img/**/*'],
                            dest: uiDestDev
                        },
                        {
                            expand: true,
                            cwd: uiRoot,
                            src: ['lib/**/*'],
                            dest: uiDestDev
                        }
                    ]
                },
                prod: {
                    files: [
                        {
                            expand: true,
                            cwd: uiRoot,
                            src: ['app/**/*'],
                            dest: uiDestProd
                        },
                        {
                            expand: true,
                            cwd: uiRoot,
                            src: ['img/**/*'],
                            dest: uiDestProd
                        },
                        {
                            expand: true,
                            cwd: uiRoot,
                            src: ['lib/**/*'],
                            dest: uiDestProd
                        }
                    ]
                }
            },
            htmlbuild: {
                dev: {
                    files: [
                        {
                            expand: true,
                            cwd: uiRoot,
                            src: [intdexHtmlFile],
                            dest: uiDestDev
                        }
                    ],
                    options: {
                        styles: {
                            styles: './' + uiDestDev + cssFile
                        }
                    }
                },
                prod: {
                    files: [
                        {
                            expand: true,
                            cwd: uiRoot,
                            src: [intdexHtmlFile],
                            dest: uiDestProd
                        }
                    ]
                }
            },
            concat_css: {
                dev: {
                    src: [uiRoot + 'css/**/*.css'],
                    dest: uiDestDev + cssFile
                },
                prod: {
                    src: [uiRoot + 'css/**/*.css'],
                    dest: uiDestProd + cssFile
                }
            }
        };

        return config;
    };

    grunt.registerTask('ui_config', function() {
        grunt.initConfig(buildConfig());
    });

    grunt.registerTask('dev', [
        'ui_config',
        'clean:dev',
        'copy:dev',
        'htmlbuild:dev',
        'concat_css:dev'
    ]);
};