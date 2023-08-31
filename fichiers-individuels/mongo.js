const database = 'pachadata';
// const collection = 'Inscriptions';

use(database);

// db.Inscriptions.findOne();
// db.Inscriptions.findOne({ "Email": "l.lefevre@abcmouseacademy.com" });
// db.Inscriptions.find({ "Email": {$regex: /^l/} });
// db.Inscriptions.find({ "Email": {$regex: /^l/} }).count();

db.Inscriptions.aggregate(
    [
        { $match: { "Email": {$regex: /^l/} }},
        { $group: { "_id": "$Titre", "count": { $sum: 1} } },
        { $sort:  { "count": -1 }}
    ]
);