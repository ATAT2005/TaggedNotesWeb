import React, { useState, useRef } from 'react';
import './../../custom.css';
import Editable from "../Editable";

/// functional component - a single tag item
const TagItem = (props) => {
    const [tag, setTag] = useState(props.name);
    const inputRef = useRef();

    function onClick() {
        props.removeItem(props.id);
    }

    function updateItem(e) {
        setTag(e);
        props.updateItem(props.id, e);
    }

    return (
        <tr>
            <td><input type="checkbox"/></td>
            <td className="tagCell">
                <Editable
                    text={tag}
                    placeholder="Write a tag name"
                    childRef={inputRef}
                    type="input">
                    <input
                        ref={inputRef}
                        type="text"
                        name="tag"
                        placeholder="Write a tag name"
                        value={tag}
                        onChange={e => updateItem(e.target.value)}/>
                </Editable>
            </td>
            <td><button onClick={onClick}>X</button></td>
        </tr>
    );
}

export default TagItem;