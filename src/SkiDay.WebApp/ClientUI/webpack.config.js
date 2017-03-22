var webpack = require("webpack")
var LiveReloadPlugin = require('webpack-livereload-plugin')
var OptimizeCssAssetsPlugin = require('optimize-css-assets-webpack-plugin')
 
module.exports = {
	entry: "./index.js",
	output: {
		path: "../Content",
		filename: "bundle.js",
		publicPath: "Content"
	},
	watch: true,
	devServer: {
		inline: true,
		contentBase: '../Content',
		port: 3003
	},
	plugins: [
    	new LiveReloadPlugin(),
        new OptimizeCssAssetsPlugin({
            assetNameRegExp: /\.optimize\.css$/g,
            cssProcessor: require('cssnano'),
            cssProcessorOptions: { discardComments: { removeAll: true } },
            canPrint: true
        })
  	],
	module: {
	    loaders: [
            {
                test: /\.js$/,
                exclude: /(node_modules)/,
                loader: ['babel'],
                query: {
                    presets: ['latest', 'stage-0', 'react']
                }
            },
            {
                test: /\.json$/,
                exclude: /(node_modules)/,
                loader: 'json-loader'
            },
            {
                test: /\.css$/,
                loader: 'style-loader!css-loader!autoprefixer-loader'

            },
            {
                test: /\.scss/,
                loader: 'style-loader!css-loader!autoprefixer-loader!sass-loader'
            }
	    ]
	}
}







