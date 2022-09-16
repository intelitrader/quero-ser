const express = require('express');
const morgan = require('morgan');
const app = express();

const { config } = require('./src/config');
const { jokenpo } = require('./src/routes');

// Allow CORS
app.use((req, res, next) => {
  res.setHeader('Access-Control-Allow-Origin', 'http://localhost:4200');
  res.setHeader('Access-Control-Allow-Headers', 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With');
  next();
});

app.use(
  morgan('dev')
);

// API routes
app.use(
  jokenpo()
);

app.listen(config().port, (err) => {
  if (err) console.log(err);
  else console.log(`Server runing on port ${config().port}`);
})