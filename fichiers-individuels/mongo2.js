const database = 'pachadata';
const collection = 'Inscriptions';

use(database);

db.Inscriptions.findOne();

db.Inscriptions.findOne({ "Email": "l.lefevre@abcmouseacademy.com" });

db.Inscriptions.find({ "Email": {$regex: /^l/} });

use('pachadata');
db.Inscriptions.find({ "Email": {$regex: /^l/} }).count();