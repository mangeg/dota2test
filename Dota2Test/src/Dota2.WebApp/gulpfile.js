/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require( "gulp" ),
    rimraf = require( "rimraf" ),
    fs = require( "fs" );

eval( "var project = " + fs.readFileSync( "./project.json" ) );

var paths = {
    bower: "./bower_components/",
    lib: "./" + project.webroot + "/lib/"
};

gulp.task( "clean", function( cb ) {
    rimraf( paths.lib, cb );
} );

gulp.task( "copy", ["clean"], function() {
    var bower = {
        "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
        "jquery": "jquery/dist/jquery*.{js,map}"
    };

    for( var destDir in bower ) {
        gulp.src( paths.bower + bower[destDir] )
            .pipe( gulp.dest( paths.lib + destDir ) );
    }
} );