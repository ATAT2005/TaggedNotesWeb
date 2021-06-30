import React from 'react';
import { TagItem } from './TagItem';

export class TagList extends React.Component {
    constructor(props) {
        super(props);

        this.state = { items: this.props.items };

        this.filterList = this.filterList.bind(this);

        this.filterRef = React.createRef();
    }

    filterList(e) {
        var filteredList = this.props.items.filter(function (item) {
            return item.name.toLowerCase().search(e.target.value.toLowerCase()) !== -1;
        });

        this.setState({ items: filteredList });
    }

    componentWillReceiveProps(props) {
        this.setState({ items: props.items })
        this.filterRef.current.value = '';
    }

    render() {
        return (
            <div>
                <input placeholder="<filter tags>" ref={this.filterRef} onChange={this.filterList} />
                <table class="datatable">
                {
                    this.state.items.map(tag => {
                        return <TagItem
                            key={tag.id}
                            id={tag.id}
                            name={tag.name}
                            removeItem={this.props.removeItem} />
                    })
                }
                </table>
            </div>);
    }
}