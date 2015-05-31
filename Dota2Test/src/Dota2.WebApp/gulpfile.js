var gulp = require( "gulp" ),
    rimraf = require( "rimraf" ),
    fs = require( "fs-extra" );

var project = fs.readJSONSync( "./project.json" );

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
        "jquery": "jquery/dist/jquery*.{js,map}",
        "angular": "angularjs/angular*.{js,map}"
    };

    for( var destDir in bower ) {
        if( bower.hasOwnProperty( destDir ) ) {
            gulp.src( paths.bower + bower[destDir] )
                .pipe( gulp.dest( paths.lib + destDir ) );
        }
    }
} );
