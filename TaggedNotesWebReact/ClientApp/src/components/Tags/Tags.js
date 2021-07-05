import React, { useState } from 'react';
import TagList from './TagList';
import AddNewTag from './AddNewTag';

/// functional component - shows all tags, allows adding new tags, deleting, filtering
const Tags = (props) => {
    const [tags, setTags] = useState(props.items);

    function addItem(tag) {
        const newList = [...tags, tag];
        setTags(newList);
    }

    function removeItem(id) {
        const newList = tags.filter(item => id !== item.id);
        setTags(newList);
    }

    function getMaxId() {
        var max = tags.reduce((acc, cur) => acc = acc > cur.id ? acc : cur.id, 1);

        return max;
    }

    //todo: extract this method to a common method in a common component Editor (which will unite Notes and Tags components)
    function saveTags() {
        fetch('tags', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(tags)
        }).then(function (response) {
            console.log(response);
        })
            .catch(function (error) {
                console.log(error);
            });
    }

    return (
        <div align="left">
            <div><button onClick={saveTags}>Save tags</button></div>
            <br />
            <div><AddNewTag tags={tags} addItem={addItem} getMaxId={getMaxId} /></div>
            <br />
            <div><TagList items={tags} removeItem={removeItem} /></div>
        </div>
    );
}

export default Tags;