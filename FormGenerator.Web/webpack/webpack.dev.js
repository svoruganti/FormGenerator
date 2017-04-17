module.exports = {
  "module": {
    "loaders": [
      {
        "test": /\.js/,
        "loader": "babel-loader",
        "exclude": /node_modules/,
        "query": {
          "presets": [
            "es2015",
            "react"
          ]
        }
      },
      {
        "test": /\.jsx/,
        "loader": "babel-loader",
        "exclude": /node_modules/,
        "query": {
          "presets": [
            "es2015",
            "react"
          ]
        }
      }
    ]
  }
}
