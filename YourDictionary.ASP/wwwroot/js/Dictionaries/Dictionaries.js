const urlRoot = `${window.location.protocol}//${window.location.hostname}:${window.location.port}`
const getPhrasesUrl = `${urlRoot}/api/PhrasesApi?dictionaryId=`
const getDictionariesUrl = `${urlRoot}/api/DictionariesApi?userId=`
const getLoggedInUser = `${urlRoot}/api/UsersApi`

let user = {}
let dictionaries = []
window.onload = async () => {
    await fetch(getLoggedInUser)
        .then(resp => resp.json())
        .then(data => {
            user = data
        })
    if (!user["id"]) window.location.href = `${urlRoot}/Account/Login`
    dictionaries = await fetch(getDictionariesUrl + user["id"]).then(resp => resp.json()).then(data => data)
    populateTable('dictionariesTableBody', dictionaries, true)

    /* TODO: 
     * populate table with dictionaries
     * add click listeners to table rows
     * when row is clicked find dictionary by id in array and display phrases
     * When clicked on phrase display related info
    */
}

const selectDictionary = (dictionaryId) => {
    return (e) => {
        const selectedDictionaryName = e.target.innerText
        console.log(`Id: ${dictionaryId}, selectedDictionaryName: ${selectedDictionaryName}`)
        populateTable('phrasesTableBody', dictionaries.find(dic => dic['id'] == dictionaryId).phrases)
    }
}

/**
 * Populates table by creating new tbody with provided values
 * @param {String} tableBodyId id of the table body to populate
 * @param {Array} data array of objects to insert in the table body
 * @param {Boolean} dataIsDictionary desides which properties to search
 */
const populateTable = (tableBodyId, data, dataIsDictionary = false) => {
    const newTableBody = document.createElement('tbody')
    newTableBody.id = tableBodyId
    data.forEach(item => {
        let tr = document.createElement('tr')
        let td = document.createElement('td')
        if (dataIsDictionary) {
            td.innerHTML = item['name']
            tr.appendChild(td)
            tr.addEventListener('click', selectDictionary(item['id']))
        } else {
            td.innerHTML = item['expression']
            tr.appendChild(td)
        }
        newTableBody.appendChild(tr);
    })
    let oldTableBody = document.getElementById(tableBodyId)
    let table = oldTableBody.parentNode
    table.removeChild(oldTableBody)
    table.appendChild(newTableBody)
}
