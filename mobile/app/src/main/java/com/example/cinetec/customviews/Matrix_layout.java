package com.example.cinetec.customviews;

import android.content.Context;
import android.util.AttributeSet;
import android.util.TypedValue;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;

import android.view.ViewGroup;
import android.widget.LinearLayout;

import androidx.annotation.Nullable;

import com.example.cinetec.R;
import com.google.android.material.button.MaterialButton;

public class Matrix_layout extends LinearLayout {
    private LinearLayout rows;
    private LinearLayout current_row;
    private MaterialButton btn;
    private int width;
    private int max_per_row=2;

    /**
     * get the max number of element per row
     * @return int the number of element per row
     */
    public int getMax_per_row() {
        return max_per_row;
    }

    /**
     * Set the max number items per row
     * @param max_per_row
     */
    public void setMax_per_row(int max_per_row) {
        this.max_per_row = max_per_row;
    }

    public Matrix_layout(Context context) {
        super(context);
        build(context);
    }

    /**
     * Class constructor
     * @param context android context
     * @param attrs view attrs
     */
    public Matrix_layout(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
        build(context);
    }

    /**
     * Class constructor
     * @param context   android context
     * @param attrs view attrs
     * @param defStyleAttr  view styles
     */
    public Matrix_layout(Context context, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        build(context);
    }

    public Matrix_layout(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        build(context);
    }

    /**
     * Builds the matriz layout in base one linear vertical layout and various linear horizontal layout
     * @param context the current android context
     */
    private void build(Context context){
        View view= LayoutInflater.from(context).inflate(R.layout.layout_matrix_container,this);
        rows=(LinearLayout) findViewById(R.id.matriz_rows);
        current_row=new LinearLayout(getContext());
        current_row.setGravity(Gravity.CENTER_HORIZONTAL);
        current_row.setLayoutParams(new LinearLayout.LayoutParams(LayoutParams.MATCH_PARENT,LayoutParams.WRAP_CONTENT));
        rows.addView(current_row);
        this.setGravity(Gravity.CENTER);
        /*
        btn=(MaterialButton) findViewById(R.id.matrix_prove_button);
        btn.setOnClickListener(new View.OnClickListener(){

            @Override
            public void onClick(View view) {
                just_proves();
            }
        });

         */
    }

    /**
     * Add a view to the matriz layout, if the current row its full, it add a new row
     * @param view
     */
    public void add_view(View view){
        int number_of_child=current_row.getChildCount();
        if(number_of_child>=max_per_row){
            current_row=new LinearLayout(getContext());
            current_row.setGravity(Gravity.CENTER_HORIZONTAL);
            current_row.setLayoutParams(new LinearLayout.LayoutParams(LayoutParams.MATCH_PARENT,LayoutParams.WRAP_CONTENT));
            rows.addView(current_row);
        }
        current_row.addView(view);

    }
    /*
    public void just_proves(){
        MovieView movie=new MovieView(getContext());
        int width = (int) TypedValue.applyDimension(
                TypedValue.COMPLEX_UNIT_DIP,
                getResources().getDimension(R.dimen.movie_size),
                getResources().getDisplayMetrics()
        );
        movie.set_cover_size(width);
        add_view(movie);
    }
   int width = (int) TypedValue.applyDimension(
            TypedValue.COMPLEX_UNIT_DIP,
            getResources().getDimension(R.dimen.movie_size),
            getResources().getDisplayMetrics()
    );*/

}
