var webpack = require("webpack");
var LiveReloadPlugin = require('webpack-livereload-plugin');
 
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
    	new LiveReloadPlugin()
  	],
	module: {
		loaders: [
			{
				test: /\.js$/,
				exclude: /(node_modules)/,
				loader: ["babel-loader"],
				query: {
					presets: ["latest", "stage-0", "react"]
				}
			},
			{
				test: /\.json$/,
				exclude: /(node_modules)/,
				loader: "json-loader"
			},
			{
				test: /\.css$/,
				loader: 'style-loader!css-loader!autoprefixer-loader'
			},
			{
				test: /\.scss$/,
				loader: 'style-loader!css-loader!autoprefixer-loader!sass-loader'
			}
		]
	}
}







