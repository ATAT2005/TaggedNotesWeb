import React, { useState, useRef } from 'react';
import './../../custom.css';
import Editable from "../Editable";

/// functional component - a single note item
const NoteItem = (props) => {
    const [note, setNote] = useState(props.text);
    const inputRef = useRef();

    function onClick() {
        props.removeItem(props.id);
    }

    function updateItem(e) {
        setNote(e);
        props.updateItem(props.id, e);
    }

    return (
        <tr>
            <td><button onClick={onClick}>X</button></td>
            <td className="noteCell">
                <Editable
                    text={note}
                    placeholder="Write a note text"
                    childRef={inputRef}
                    type="input">
                    <input
                        ref={inputRef}
                        type="text"
                        name="note"
                        placeholder="Write a note text"
                        value={note}
                        onChange={e => updateItem(e.target.value)} />
                </Editable>
            </td>
            <td className="linkedTagsCell">{props.linkedTags}</td>
        </tr>
    );
}

export default NoteItem;