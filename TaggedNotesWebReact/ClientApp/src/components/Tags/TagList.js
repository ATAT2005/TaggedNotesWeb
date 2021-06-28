import React from 'react';
import { TagItem } from './TagItem';

export class TagList extends React.Component {
    constructor(props) {
        super(props);

        this.state = { items: this.props.items };

        this.filterList = this.filterList.bind(this);
    }

    filterList(e) {
        var filteredList = this.props.items.filter(function (item) {
            return item.name.toLowerCase().search(e.target.value.toLowerCase()) !== -1;
        });

        this.setState({ items: filteredList });
    }

    render() {
        return (
            <div>
                <input placeholder="<filter tags>" onChange={this.filterList} />
                {
                    this.state.items.map(tag => {
                        return <TagItem
                            key={tag.id}
                            id={tag.id}
                            name={tag.name}
                            removeItem={this.props.removeItem} />
                    })
                }
            </div>);
    }
}