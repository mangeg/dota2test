var gulp = require( "gulp" ),
    fs = require( "fs-extra" ),
    tsc = require( "gulp-typescript" ),
    tslint = require( 'gulp-tslint' ),
    sourcemaps = require( 'gulp-sourcemaps' ),
    clean = require( "gulp-clean" ),
    typescript = require( "typescript" ),
    merge = require("merge2"),
    Config = require( "./gulpfile.config" );

var config = new Config();
var project = fs.readJSONSync( "./project.json" );
var tsProj = tsc.createProject( {
    target: "ES5",
    noExternalResolve: true,
    typescript: typescript,
    declarationFiles: false,
    module: "commonjs"
} );

var paths = {
    bower: "./bower_components/",
    lib: "./" + project.webroot + "/lib/",
    app: "./" + project.webroot + "/app/"
};

gulp.task( "compile-ts", ["clean-ts"], function() {
    var sourceTsFiles = [config.allTs];

    var tsResult = gulp.src( sourceTsFiles )
        .pipe( sourcemaps.init() )
        .pipe( tsc( tsProj ) );

    return merge( [
        tsResult.dts.pipe( gulp.dest( config.tsOutputPath ) ),
        tsResult.js.pipe( sourcemaps.write( "." ) )
        .pipe( gulp.dest( config.tsOutputPath ) )
    ] );
} );

gulp.task( "clean-ts", function() {
    var typeScriptGenFiles = [
        config.tsOutputPath,
        paths.app + "**/*.{js,map}",
        config.source + "/*.{js,map}"
    ];

    return gulp.src( typeScriptGenFiles, { read: false } )
        .pipe( clean() );
} );

gulp.task( "copy-ts-output", ["compile-ts"], function() {
    var typeScriptGenFiles = [
        config.allJs
    ];
    return gulp.src( typeScriptGenFiles )
       .pipe( gulp.dest( paths.app ) );
} );

gulp.task( "watch", function() {
    return gulp.watch( [config.allTs], ["compile-ts", "copy-ts-output"] );
} );

gulp.task( "clean", function() {
    var foldersToClean = [paths.lib, paths.app];
    return gulp.src( foldersToClean, { read: false } )
        .pipe( clean() );
} );

gulp.task( "copy", ["clean", "compile-ts", "copy-ts-output"], function() {
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

gulp.task( "default", ["copy"] );